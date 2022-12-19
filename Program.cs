using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeTheGame
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public enum MoveDirection : int
        {
            Up,
            Down,
            Left,
            Right 
        }
        
        private static LinkedList<RecordsTableNode> _recordsTable = new LinkedList<RecordsTableNode>();

        private static void ReadRecordsTable()
        {
            try
            {
                using (BinaryReader reader = new BinaryReader(File.Open("rectable", FileMode.OpenOrCreate)))
                {
                    while (reader.PeekChar() > -1)
                    {
                        var nick = reader.ReadString();
                        var points = reader.ReadInt32();
                        _recordsTable.AddLast(new RecordsTableNode(nick,points));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void WriteRecordsTable()
        {
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open("rectable", FileMode.OpenOrCreate)))
                {
                    foreach (var item in _recordsTable)
                    {
                        writer.Write(item.Nickname);
                        writer.Write(item.Points);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        
        public static (bool,int) ChangeRecordsTable(string nick,int points)
        {

            if (_recordsTable.Count == 0)
            {
                _recordsTable.AddFirst(new RecordsTableNode(nick, points));
                return (true, 1);
            }

            if (_recordsTable.Last.Value.Points >= points && _recordsTable.Count == 10)
                return (false, 0);


            var node = _recordsTable.First;
            int i = 1;
            
            do
            {
                if (node.Value.Points < points)
                    break;
                
                
                i++;
                node = node.Next;

            } while (node != null);

            if (node != null)
                _recordsTable.AddBefore(node, new RecordsTableNode(nick, points));
            
            else if (_recordsTable.Count == i-1 && _recordsTable.Count<10)
                _recordsTable.AddLast(new RecordsTableNode(nick, points));

            while (_recordsTable.Count > 10)
                _recordsTable.RemoveLast();

            if (i > 10)
                return (false, 0);
            
            return (true, i);
        }

        public static LinkedList<RecordsTableNode> GetRecordsTable()
        {
            return new LinkedList<RecordsTableNode>(_recordsTable);
        }


        [STAThread]
        static void Main()
        {
            ReadRecordsTable();
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            Application.Run(new Form1());
            
            WriteRecordsTable();
        }
    }
}