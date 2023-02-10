
using System;
using Xunit;

public class ExampleTests
{
    [Fact]
    public void TestUnitario()
    {
        // Arrange
        var calculator = new Calculator();

        // Act
        var result = calculator.Add(1, 2);

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void TestIntegracao()
    {
        // Arrange
        var db = new Database();
        var service = new Service(db);

        // Act
        var result = service.GetData();

        // Assert
        Assert.NotEmpty(result);
    }

    [Fact]
    public void TestAceitacao()
    {
        // Arrange
        var app = new Application();

        // Act
        var result = app.Login("username", "password");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void TestCarga()
    {
        // Arrange
        var data = GetLargeDataSet();
        var app = new Application();

        // Act
        var stopwatch = Stopwatch.StartNew();
        var result = app.ProcessData(data);
        stopwatch.Stop();

        // Assert
        Assert.True(stopwatch.ElapsedMilliseconds < 1000);
    }

    [Fact]
    public void TestRegressao()
    {
        // Arrange
        var app = new Application();
        var initialData = app.GetData();

        // Act
        app.Update();
        var updatedData = app.GetData();

        // Assert
        Assert.Equal(initialData, updatedData);
    }

    [Fact]
    public void TestSeguranca()
    {
        // Arrange
        var app = new Application();

        // Act
        var result = app.Search("'); DROP TABLE Users;--");

        // Assert
        Assert.Throws<SqlException>(() => result);
    }

    [Fact]
    public void TestConsistencia()
    {
        // Arrange
        var app = new Application();

        // Act
        var result = app.GetData();

        // Assert
        Assert.All(result, item => Assert.IsType<int>(item));
    }

    [Fact]
    public void TestManutencao()
    {
    // Arrange
    var code = @"public class MyClass {public void MyMethod() {// Complex and hard to understand code}}";


        // Act
        var maintainabilityIndex = GetMaintainabilityIndex(code);

        // Assert
        Assert.True(maintainabilityIndex > 70);
    }
}