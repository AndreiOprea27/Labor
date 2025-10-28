using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labor
{
    internal class AstPlotter
    {
        public static void PlotAst(AstNode node)
        {
            AstBuilder.PrintAst(node);

        }
    }
}
