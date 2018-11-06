using System;

namespace 로깅
{
    internal static class Program
    {
        public static Logging Logger = new Logging("log.log");

        private static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Logger.Log($"{i} 평범한 로그 ㅁㄴㅇㅁ");
            }

            Logger.Log("정보 ㅁㄴㅇㅁㄴㅇ", Logging.Level.Info);
            Logger.Log("경고! ㅁㄴㅇㅁ", Logging.Level.Warn);
            Logger.Log("에러발생! ㅁㄴㅇㅁㄴ", Logging.Level.Error);

            Console.ReadLine();
        }
    }
}
