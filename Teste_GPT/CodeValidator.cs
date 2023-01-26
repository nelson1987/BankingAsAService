using System;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

class CamelCaseValidator
{
    public void Validate(string solutionPath)
    {
        var workspace = MSBuildWorkspace.Create();
        var solution = workspace.OpenSolutionAsync(solutionPath).Result;

        foreach (var project in solution.Projects)
        {
            var compilation = project.GetCompilationAsync().Result;
            var semanticModel = compilation.GetSemanticModel(compilation.SyntaxTrees.First());

            var variables = compilation.SyntaxTrees
                .SelectMany(t => t.GetRoot().DescendantNodes())
                .OfType<VariableDeclaratorSyntax>();

            foreach (var variable in variables)
            {
                var symbol = semanticModel.GetDeclaredSymbol(variable);
                if (!IsCamelCase(symbol.Name))
                {
                    Console.WriteLine($"Variable '{symbol.Name}' is not in CamelCase format.");
                }
            }
        }
    }

    private bool IsCamelCase(string name)
    {
        if (string.IsNullOrEmpty(name))
            return true;

        if (!char.IsLower(name[0]))
            return false;

        for (int i = 1; i < name.Length; i++)
        {
            if (!char.IsLower(name[i]) && !char.IsDigit(name[i]))
                return false;
        }

        return true;
    }
}
