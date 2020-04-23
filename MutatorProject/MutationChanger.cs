using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MutatorProject
{
    internal class MutationChanger : CSharpSyntaxRewriter
    {
        public static SyntaxTree originalCodeTree;
        public static SyntaxNode mutatedCodeNode;
        public static SyntaxTree MutatedCodeTree;
        public static List<SyntaxNode> listOfMutatedCodes;
        public static void BeginMutation(CodeFile codeFile)
        {

            SyntaxTree tree = CSharpSyntaxTree.ParseText(codeFile.text);
            originalCodeTree = tree;
            var root = tree.GetRoot();
            mutatedCodeNode = new VirtualizationVisitor()
                            .Visit(tree.GetRoot());
            MutatedCodeTree = CSharpSyntaxTree.ParseText(mutatedCodeNode.ToString());
            //Отсюда можно отправить на компиляцию
            listOfMutatedCodes.Add(mutatedCodeNode);
            //StreamWriter codeMutation = new StreamWriter
        }
    }
}