using System;
using Microsoft.CodeAnalysis.CSharp;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MutatorProject
{
    public class VirtualizationVisitor: CSharpSyntaxRewriter
    {
        public override SyntaxNode VisitBlock(BlockSyntax node)
        {
            var SyntaxListCode = node.ChildNodes();
            SyntaxList<StatementSyntax> mutate = new SyntaxList<StatementSyntax>();
            foreach (StatementSyntax child in SyntaxListCode)
            {

                //Здесь идет перебор и отправяется на переработку завсимости от типа оператора или метода;
            }
            if (node.DescendantNodes().OfType<BlockSyntax>().Count() >= 1)
                return node.Update(node.OpenBraceToken,
                                  new SyntaxList<StatementSyntax>(),
                                  node.CloseBraceToken);

            return base.VisitBlock(node);
        }
    }
}
