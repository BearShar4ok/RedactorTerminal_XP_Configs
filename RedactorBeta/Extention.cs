using System.Linq;

namespace RedactorBeta
{
    public static class Extention
    {
        //for debug and test
        public static string LevelUp_Debug(this string path)
        {
            return path.Remove(path.Length - 1 - path.Split('\\').Last().Length);
        }
    }
}
