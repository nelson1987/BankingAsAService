Aqui está um exemplo de como você poderia escrever uma classe em C# 7.0 que valida se todas as variáveis string de um código começam com "str" e impede que o projeto seja compilado se não estiverem escritas corretamente:

Copy code
using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
public class StringVariablePrefixAnalyzer : DiagnosticAnalyzer
{
    public const string DiagnosticId = "StringVariablePrefix";
    private static readonly LocalizableString Title = "String variable prefix";
    private static readonly LocalizableString MessageFormat = "All string variables must start with 'str'";
    private static readonly LocalizableString Description = "All string variables must start with 'str'";
    private const string Category = "Naming";

    private static DiagnosticDescriptor Rule = new DiagnosticDescriptor(DiagnosticId, Title, MessageFormat, Category, DiagnosticSeverity.Error, isEnabledByDefault: true, description: Description);

    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get { return ImmutableArray.Create(Rule); } }

    public override void Initialize(AnalysisContext context)
    {
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
        context.EnableConcurrentExecution();
        context.RegisterSyntaxNodeAction(AnalyzeVariableDeclaration, SyntaxKind.VariableDeclaration);
    }

    private void AnalyzeVariableDeclaration(SyntaxNodeAnalysisContext context)
    {
        var variableDeclaration = (VariableDeclarationSyntax)context.Node;
        if (variableDeclaration.Type.ToString() != "string")
        {
            return;
        }

        foreach (var variable in variableDeclaration.Variables)
        {
            if (!variable.Identifier.ValueText.StartsWith("str"))
            {
                var diagnostic = Diagnostic.Create(Rule, variable.GetLocation(), variable.Identifier.ValueText);
                context.ReportDiagnostic(diagnostic);
            }
        }
    }
}
Essa classe usa o Microsoft.CodeAnalysis para analisar o código e verificar se todas as variáveis do tipo string começam com "str". Se uma variável não estiver escrita corretamente, ela adiciona um diagnostic apropriado à lista de erros do Visual Studio com a mensagem "Todas as variáveis do tipo string, devem iniciar com str" e impede que o projeto seja compilado.

É importante notar que essa classe deve ser registrada e habilitada no seu projeto, caso contrário ela não irá funcionar.




Nelson Neto
como referenciar um projeto de análise de código no projeto que será analisado?
Para referenciar um projeto de análise de código no projeto que será analisado, você precisará seguir os seguintes passos:

Certifique-se de que o projeto de análise de código esteja incluído na sua solução e que ele já tenha sido compilado.

Abra o projeto que você deseja analisar e adicione uma referência ao projeto de análise de código. Isso pode ser feito clicando com o botão direito do mouse no projeto de destino e selecionando "Adicionar > Referência...". Em seguida, selecione o projeto de análise de código na lista de projetos disponíveis e clique em "OK".

Abra o arquivo de código fonte onde você deseja habilitar a análise de código e adicione a seguinte linha de código no topo do arquivo:

Copy code
#pragma warning disable <ID_do_aviso>
Para habilitar a análise de código, você precisará adicionar a seguinte linha no arquivo csproj do projeto de destino:
Copy code
<PropertyGroup>
    <CodeAnalysisRuleSet>path/to/ruleset.ruleset</CodeAnalysisRuleSet>
</PropertyGroup>
Agora, quando você compilar o projeto de destino, o projeto de análise de código será executado e qualquer aviso ou erro será exibido na lista de erros do Visual Studio.
Obs: é importante notar que essa configuração pode variar de acordo com o ambiente de desenvolvimento utilizado, caso seja necessário mais detalhes, consulte a documentação do seu ambiente.



Regenerate response

ChatGPT Jan 9 Version.