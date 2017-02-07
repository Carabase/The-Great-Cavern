using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class NPCManager
    {
        public List<NPC> Initialize()
        {
            NPC NPC0 = new NPC(8, "Old Miner", Miner_Behaviour, Miner_Dialogue, 0);

            List<NPC> NPCS = new List<NPC>(new NPC[] { NPC0 });
            return NPCS;
        }

    }
}
