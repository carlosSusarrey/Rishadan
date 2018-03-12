using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rishadan
{
    public class Cell
    {
        public Life Alive { get; }

        public Cell(Life alive)
        {
            Alive = alive;
        }

        public Cell EvolveCell(ICollection<Cell> neighbourCells)
        {
            var aliveNeighbours = neighbourCells.Count(x => x.Alive == Life.Alive);
            // If Cell is dead and has exactly three alive neighbour it gets to live
            if (Alive == Life.Dead) return aliveNeighbours == 3 ? new Cell(Life.Alive) : new Cell(Life.Dead);
            // If cell has less than 2 neighbours it dies for undepopulation
            if (aliveNeighbours < 2)
            {
                return new Cell(Life.Dead);
            }
            // If cell has more than 3 alive neighbours it dies for overpopulation
            return aliveNeighbours < 4 ? new Cell(Life.Alive) : new Cell(Life.Dead);
        }
    }
}
