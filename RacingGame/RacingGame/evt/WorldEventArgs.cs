using System;

namespace RacingGame.core {
    internal class WorldEventArgs {
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }

        public WorldEventArgs(string msg, DateTime time) {
            Message = msg;
            Timestamp = time;
        }
    }
}