using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongRenamer
{
	class Program
	{
		static void Main(string[] args)
		{
			//String pathToFile = @"C:\Users\path\to\music.mp3";

			// useful properties from the TagLib File class
			//TagLib.File tagFile = TagLib.File.Create(pathToFile);
			//string artist = tagFile.Tag.FirstAlbumArtist;
			//string album = tagFile.Tag.Album;
			//string title = tagFile.Tag.Title;

			DoStuff();
		}

		/// <summary>
		/// Iterates through files in a folder and attempts to extract the song title
		/// from the song's metadata. Specialized for the weird folder format on old
		/// iPods but could be tweaked to work more generically.
		/// </summary>
		private static void DoStuff()
		{

			// iPod stores songs in weird folders named like FXY, so you might be able
			// to just loop through this list of folder names. I don't know if this is
			// true of all iPods or just the one I helped with though so just use caution
			List<String> folderNames = new List<String>()
			{
				"F04", "F05", "F06", "F07",
				"F08", "F09", "F10", "F11", "F12", "F13"
			};


			// src is the folder where the iPod music folders are located, like the FXY folders
			String src = @"";         // NEED TO SPECIFY THIS

			// dst is where you'd like the new song files to go
			String dst = @"";         // AND THIS

			// dstOrphans is for songs that have no title in the metadata and will need manual renaming
			String dstOrphans = @"";  // ALSO THIS

			if (String.IsNullOrEmpty(src) || String.IsNullOrEmpty(dst) || String.IsNullOrEmpty(dstOrphans))
			{
				// must specify file paths
				return;
			}

			String folder = "F13";
			String srcPath = src + folder;
			String[] files = Directory.GetFiles(srcPath);
			foreach (var file in files)
			{
				TagLib.File tagFile = TagLib.File.Create(file);
				String title = tagFile.Tag.Title;
				if (!String.IsNullOrEmpty(title))
				{
					// rename and copy to ouptut
					String newName = dst + GetSafeFilename(title) + Path.GetExtension(file);
					if (File.Exists(newName))
					{
						String uhoh = "";  // who needs error handling
					}
					File.Copy(file, newName);
				}
				else
				{
					// copy to orphans D:
					String newName = dstOrphans + Path.GetFileName(file);
					if (File.Exists(newName))
					{
						String uhoh = "";  // this is fine
					}
					File.Copy(file, newName);
				}
			}
			return;
		}

		/// <summary>
		/// Removes unsafe filepath characters from song names and replaces with an underscore
		/// </summary>
		/// <param name="filename">Filename to sanitize</param>
		/// <returns></returns>
		private static String GetSafeFilename(String filename)
		{
			return String.Join("_", filename.Split(Path.GetInvalidFileNameChars()));
		}

	}
}
