using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace DataOriented.Analyzers
{
	[Generator]
	public class MultiListGenerator : ISourceGenerator
	{
		class SyntaxReceiver : ISyntaxReceiver
		{
			public List<StructDeclarationSyntax> Structs { get; } = new List<StructDeclarationSyntax>();
			
			public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
			{
				if (!(syntaxNode is StructDeclarationSyntax _)) { return; }
				var decl = syntaxNode as StructDeclarationSyntax;
				
				// Struct has no attributes
				if (decl.AttributeLists.Count == 0) { return; }
				
				// Struct has no MultiList attribute
				var attribute = decl.AttributeLists[0].Attributes[0];
				if (attribute.Name.ToString() == "MultiList")
				{
					Structs.Add(decl);
				}
			}
		}

		public void Initialize(GeneratorInitializationContext context)
		{
			throw new NotImplementedException();
		}
		public void Execute(GeneratorExecutionContext context)
		{
			throw new NotImplementedException();
		}
	}
	
}



