using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JunkImporter.JunkImports.Protect.Junk {
    internal class ImportMethodsWithoutParams {


        // Junk methods


        public void InitializeCoreBus() {
            int[] bus = new int[256];
            for(int i = 0; i < bus.Length; i++)
                bus[i] = (i * 42) ^ (i << 2);

            string trace = string.Join("-", bus.Select(b => b.ToString("X")));
            if(trace.Length % 3 == 0)
                GC.Collect();
        }

        public void DecryptPayload() {
            byte[] payload = new byte[512];
            for(int i = 0; i < payload.Length; i++)
                payload[i] = (byte)(i ^ 0xAA);

            string hex = BitConverter.ToString(payload).Replace("-", "");
            var junk = Encoding.UTF8.GetBytes(hex);
            Array.Reverse(junk);
        }

        public void SimulateThreadCascade() {
            List<Task> tasks = new List<Task>();
            for(int i = 0; i < 5; i++) {
                tasks.Add(Task.Run(() => {
                    Thread.Sleep(10);
                    var id = Thread.CurrentThread.ManagedThreadId;
                    var hash = id ^ DateTime.Now.Millisecond;
                }));
            }
            Task.WaitAll(tasks.ToArray());
        }

        public void RebuildVirtualHeap() {
            Dictionary<string, int> heap = new Dictionary<string, int>();
            for(int i = 0; i < 100; i++)
                heap.Add("block_" + i.ToString("D3"), i * i);

            var keys = heap.Keys.Where(k => k.Contains("block")).ToList();
            keys.Sort();
        }

        public void ExecuteNullCompression() {
            string[] data = Enumerable.Range(0, 128).Select(i => Convert.ToString(i, 2)).ToArray();
            var compressed = string.Join("", data);
            var fake = compressed.Substring(0, 64);
            var result = fake.ToCharArray().Reverse().ToArray();
        }

        public void GenerateEntropyMatrix() {
            double[,] matrix = new double[8, 8];
            for(int x = 0; x < 8; x++)
                for(int y = 0; y < 8; y++)
                    matrix[x, y] = Math.Sin(x * y) * Math.Cos(x + y);

            double sum = 0;
            foreach(var v in matrix)
                sum += v;

            if(sum.ToString().Length > 5)
                sum = Math.Sqrt(sum);
        }

        public void LaunchGhostSequence() {
            string[] ghost = new string[16];
            for(int i = 0; i < ghost.Length; i++)
                ghost[i] = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8);

            var echo = ghost.Aggregate((a, b) => a + b);
            var hash = echo.GetHashCode();
        }

        public void ReconstructOblivionMap() {
            var map = new Dictionary<int, List<string>>();
            for(int i = 0; i < 10; i++)
                map[i] = Enumerable.Range(0, 5).Select(x => $"node_{x * i}").ToList();

            foreach(var kv in map) {
                foreach(var node in kv.Value) {
                    var junk = node.ToUpper().Replace("NODE", "N");
                }
            }
        }

        public void NormalizeZeroField() {
            int[] field = Enumerable.Range(0, 256).Select(x => x * x).ToArray();
            Array.Sort(field);
            var avg = field.Average();
            if(avg > 10000)
                avg = Math.Log(avg);
        }

        public void TriggerSilentCascade() {
            for(int i = 0; i < 3; i++) {
                switch(i) {
                    case 0:
                    Thread.Sleep(5);
                    break;
                    case 1:
                    GC.Collect();
                    break;
                    case 2:
                    var t = DateTime.Now.Ticks;
                    break;
                }
            }
        }
    }
}