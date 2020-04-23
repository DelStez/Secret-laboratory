using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MutatorProject
{
    public class CoreReplace : CSharpSyntaxRewriter
    {
        public static SyntaxNode VisitIfStatement(IfStatementSyntax node)
        {
            var body = node.Statement;
            var block = SyntaxFactory.Block(body);
            var newIfStatement = node.WithStatement(block);

            return newIfStatement;
        }
        public static SyntaxNode VisitIfStatement(WhileStatementSyntax node)
        {
            var body = node.Statement;
            var block = SyntaxFactory.Block(body);
            var newIfStatement = node.WithStatement(block);

            return newIfStatement;
        }
    }
}
