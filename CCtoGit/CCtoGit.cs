using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using log4net;
using log4net.Config;

namespace CCtoGit
{
  public class CCtoGit
  {
    static void Main(string[] args)
    {
      string absVobPath = GetVobPath();
      string absRepoPath = GetRepoPath();

      Clone(absVobPath, absRepoPath);
    }

    private static void Clone(string absVobPath, string absRepoPath)
    {
      Console.WriteLine(absVobPath + " 를 " + absRepoPath + " 로 이전합니다.");

      new Git.Init(absRepoPath);

    }

    private static string GetVobPath()
    {
      string absVobPath = string.Empty;

      while (string.IsNullOrWhiteSpace(absVobPath))
      {
        Console.WriteLine("이전할 ClearCase VOB 의 절대 경로를 입력 하세요. VOB 은 dynamic view 여야 합니다.");
        Console.Write("> ");
        absVobPath = Console.ReadLine();

        try
        {
          if (!Path.IsPathRooted(absVobPath))
          {
            Console.WriteLine("입력한 경로는 절대 경로가 아닙니다. 다시 입력 해 주세요.");
            absVobPath = string.Empty;
            continue;
          }
        }
        catch (ArgumentException e)
        {
          Console.WriteLine(e.Message);
          absVobPath = string.Empty;
          continue;
        }
      }
      return absVobPath;
    }

    private static string GetRepoPath()
    {
      string absRepoPath = string.Empty;

      while (string.IsNullOrWhiteSpace(absRepoPath))
      {
        Console.WriteLine("생성 할 Git Repository 의 절대 경로를 입력 하세요.");
        Console.Write("> ");
        absRepoPath = Console.ReadLine();

        try
        {
          if (!Path.IsPathRooted(absRepoPath))
          {
            Console.WriteLine("입력한 경로는 절대 경로가 아닙니다. 다시 입력 해 주세요.");
            absRepoPath = string.Empty;
            continue;
          }
        }
        catch (ArgumentException e)
        {
          Console.WriteLine(e.Message);
          absRepoPath = string.Empty;
          continue;
        }

        if (Directory.Exists(absRepoPath))
        {
          Console.WriteLine("입력한 경로는 이미 존재하는 폴더입니다. 기존 폴더를 백업 또는 삭제하고 진행 해 주세요.");
          absRepoPath = string.Empty;
          continue;
        }
      }

      return absRepoPath;
    }
  }
}
