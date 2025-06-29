using System;
using System.IO;
using MyShogi.Model.Shogi;
using MyShogi.Model.Shogi.Core;
using MyShogi.Model.Shogi.Converter.Svg;
using MyShogi.Model.Shogi.Kifu;
using MyShogi.App;
using MyShogi.Model.Common.Utility;
using MyShogi.Model.Shogi.LocalServer;
using System.Text;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Initializer.Init();
        if (args.Length == 0)
        {
            Console.WriteLine("SFENをコマンド引数で指定してください。");
            return;
        }

        try
        {
            var pos = new Position();
            pos.SetSfen(args[0]);

            var header = new KifuHeader
            {
                PlayerNameBlack = "先手",
                PlayerNameWhite = "後手",
            };

            var svg = new Svg().ToString(pos, header);
            var outputPath = args.Length >= 2 ? args[1] : "output.svg";
            System.IO.File.WriteAllText(outputPath, svg);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}
