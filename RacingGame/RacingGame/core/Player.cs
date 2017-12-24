using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingGame.core {
    internal class Player {
        public Guid PID { get; } = Guid.NewGuid();
        protected long _mIdle = 0;
        public long MillisIdle {
            get {
                return _mIdle;
            }
            set {
                _mIdle = value;
            }
        }
        private World world = null;

        public Player() {

        }

        public Player(World w) {
            world = w;
        }

        public void Join(World w) {

        }

        public void Leave(World w) {

        }

    }
}