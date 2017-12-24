using RacingGame.evt;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace RacingGame.core {
    internal class World {
        private List<Player> _players = new List<Player>();
        public Player[] Players {
            get { return _players.ToArray(); }
            private set { _players = value.ToList(); }
        }

        private Size _bounds;
        public Size Boundaries {
            get { return _bounds; }
            set { _bounds = value; }
        }

        public TimeSpan Timeout { get; set; }

        private Timer timer;

        public delegate void WorldEventHandler(object sender, WorldEventArgs e);
        public event WorldEventHandler OnWorldEvent;
        public delegate void PlayerJoinHandler(object sender, PlayerJoinEventArgs e);
        public event PlayerJoinHandler OnPlayerJoin;
        public delegate void PlayerLeaveHandler(object sender, PlayerLeaveEventArgs e);
        public event PlayerLeaveHandler OnPlayerLeave;
        
        public World(int xSize, int ySize) {
            Boundaries = new Size(xSize, ySize);
            Timeout = TimeSpan.FromSeconds(500d);
            timer = new Timer();
            timer.Interval = 10;
            timer.Tick += (s, e) => {
                _players.ForEach(player => {
                    if (player.MillisIdle >= Timeout.TotalMilliseconds)
                        KickPlayer(player);
                    else
                        player.MillisIdle += 10;
                });
            };
        }

        public void AddPlayer(Player p) {
            _players.ForEach(player => {
                if (player.PID == p.PID)
                    return;
            });
            _players.Add(p);
            OnPlayerJoin(this, new PlayerJoinEventArgs());
        }

        public void KickPlayer(Player p) {
            _players.ForEach(player => {
                if (player.PID == p.PID) {
                    _players.Remove(player);
                    OnPlayerLeave(this, new PlayerLeaveEventArgs());
                }
            });
        }
    }
}