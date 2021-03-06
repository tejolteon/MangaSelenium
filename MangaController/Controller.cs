﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MangaController
{
    using Manga = MangaDownload.Generic;

    public class Controller
    {
        public static List<string> logs = new List<string>();

        public static void GetLog()
        {
            string l = "Processo Iniciado";
            logs.Add(l);

            while (true)
            {
                if (l != Manga.file && Manga.file != null)
                {
                    l = Manga.file;
                    logs.Add(l);
                }

                if (l == "Fim da Execução")
                    break;
            }

            Manga.file = string.Empty;
        }

        public static void Download(string url, string manga, bool navegador, int capitulo, int volume, string path, int volNumber)
        {
            try
            {
                new Task(() => { Manga.Start(url, manga, navegador, capitulo, volume, path, volNumber); }).Start();
                new Task(GetLog).Start();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public static void DownloadH(string url, string manga, bool navegador, string path)
        {
            try
            {
                new Task(() => { Manga.StartH(url, manga, navegador, path); }).Start();
                new Task(GetLog).Start();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
