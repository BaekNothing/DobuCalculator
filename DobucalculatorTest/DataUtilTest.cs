using Xunit;
using DobuCalCulator;
using System.Reflection;
using System.Numerics;

namespace DobucalculatorTest
{
    public class DataUtilTest
    {
        [Fact]
        public void GetTestError()
        {
            MethodInfo? methodInfo = 
                typeof(DataUtil).GetMethod("GetT", 
                BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.NotNull(methodInfo);

            MethodInfo? notCorrectTypeMethod = methodInfo?.MakeGenericMethod(typeof(decimal));
            DataUtil dataUtil = new DataUtil();
            Assert.Throws<System.ArgumentException>(() => {
                notCorrectTypeMethod?.Invoke(dataUtil, new object[]{"5", 0, 10});
            });
        }

        [Fact]
        public void GetTIntTest()
        {
            MethodInfo? methodInfo = 
                typeof(DataUtil).GetMethod("GetT", 
                BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.NotNull(methodInfo);

            MethodInfo? intMethod = methodInfo?.MakeGenericMethod(typeof(int));
            DataUtil dataUtil = new DataUtil();
            object? result = null;
            result = intMethod?.Invoke(dataUtil, new object[]{"5", 0, 10});
            Assert.Equal("5", result?.ToString());
            result = intMethod?.Invoke(dataUtil, new object[]{"0", 0, 0});
            Assert.Equal("0", result?.ToString());
        }
    
        [Fact]
        public void GetTIntTest_Error()
        {
            MethodInfo? methodInfo = 
                typeof(DataUtil).GetMethod("GetT", 
                BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.NotNull(methodInfo);

            MethodInfo? intMethod = methodInfo?.MakeGenericMethod(typeof(int));
            DataUtil dataUtil = new DataUtil();
            
            Assert.Throws<System.Reflection.TargetInvocationException>(() => {
                intMethod?.Invoke(dataUtil, new object[]{"not number", 0, 10});});
            Assert.Throws<System.Reflection.TargetInvocationException>(() => {
                intMethod?.Invoke(dataUtil, new object[]{"-", 0, 10});});
            Assert.Throws<System.Reflection.TargetInvocationException>(() => {
                intMethod?.Invoke(dataUtil, new object[]{"", 0, 10});});
            Assert.Throws<System.Reflection.TargetInvocationException>(() => {
                intMethod?.Invoke(dataUtil, new object[]{" ", 0, 10});});
            Assert.Throws<System.Reflection.TargetInvocationException>(() => {
                intMethod?.Invoke(dataUtil, new object[]{"42", 0, 10});});
            Assert.Throws<System.Reflection.TargetInvocationException>(() => {
                intMethod?.Invoke(dataUtil, new object[]{"-42", 0, 10});});
        }

        [Fact]
        public void GetTDoubleTest()
        {
            MethodInfo? methodInfo = 
                typeof(DataUtil).GetMethod("GetT", 
                BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.NotNull(methodInfo);

            MethodInfo? doubleMethod = methodInfo?.MakeGenericMethod(typeof(double));
            DataUtil dataUtil = new DataUtil();
            object? result = null;
            result = doubleMethod?.Invoke(dataUtil, new object[]{"5", 0, 10});
            Assert.Equal("5", result?.ToString());
            result = doubleMethod?.Invoke(dataUtil, new object[]{"0", 0, 0});
            Assert.Equal("0", result?.ToString());
        }
        
        [Fact]
        public void GetTDoubleTest_Error()
        {
            MethodInfo? methodInfo = 
                typeof(DataUtil).GetMethod("GetT", 
                BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.NotNull(methodInfo);

            MethodInfo? doubleMethod = methodInfo?.MakeGenericMethod(typeof(double));
            DataUtil dataUtil = new DataUtil();
            
            Assert.Throws<System.Reflection.TargetInvocationException>(() => {
                doubleMethod?.Invoke(dataUtil, new object[]{"not number", 0, 10});});
            Assert.Throws<System.Reflection.TargetInvocationException>(() => {
                doubleMethod?.Invoke(dataUtil, new object[]{"-", 0, 10});});
            Assert.Throws<System.Reflection.TargetInvocationException>(() => {
                doubleMethod?.Invoke(dataUtil, new object[]{"", 0, 10});});
            Assert.Throws<System.Reflection.TargetInvocationException>(() => {
                doubleMethod?.Invoke(dataUtil, new object[]{" ", 0, 10});});
            Assert.Throws<System.Reflection.TargetInvocationException>(() => {
                doubleMethod?.Invoke(dataUtil, new object[]{"42", 0, 10});});
            Assert.Throws<System.Reflection.TargetInvocationException>(() => {
                doubleMethod?.Invoke(dataUtil, new object[]{"-42", 0, 10});});
        }

        [Fact]
        public void ConvertTypeTest_Error()
        {
            MethodInfo? methodInfo = 
                typeof(DataUtil).GetMethod("ConvertType", 
                BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.NotNull(methodInfo);
            DataUtil dataUtil = new DataUtil();

            MethodInfo? notCorrectTypeMethod = methodInfo?.MakeGenericMethod(typeof(decimal));
            Assert.Throws<System.Reflection.TargetInvocationException>(() => {
                notCorrectTypeMethod?.Invoke(dataUtil, new object[]{"0"});});
        }

        [Fact]
        public void ConvertTypeTest_Int()
        {
            MethodInfo? methodInfo = 
                typeof(DataUtil).GetMethod("ConvertType", 
                BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.NotNull(methodInfo);
            DataUtil dataUtil = new DataUtil();

            MethodInfo? intMethod = methodInfo?.MakeGenericMethod(typeof(int));
            if(intMethod != null)
            {
                object? result = null;
                result = 
                    intMethod?.Invoke(dataUtil, new object[]{"0"});
                Assert.Equal(0, result);
                result = 
                    intMethod?.Invoke(dataUtil, new object[]{"2147483647"});
                Assert.Equal(2147483647, result);
                result = 
                    intMethod?.Invoke(dataUtil, new object[]{"-2147483648"});
                Assert.Equal(-2147483648, result);
                result = 
                    intMethod?.Invoke(dataUtil, new object[]{"42"});
                Assert.Equal(42, result);
                result = 
                    intMethod?.Invoke(dataUtil, new object[]{"3141592"});
                Assert.Equal(3141592, result);
                result = 
                    intMethod?.Invoke(dataUtil, new object[]{"-3141592"});
                Assert.Equal(-3141592, result);
            }
        }

        [Fact]
        public void ConvertTypeTest_Int_Error()
        {
            MethodInfo? methodInfo = 
                typeof(DataUtil).GetMethod("ConvertType", 
                BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.NotNull(methodInfo);
            DataUtil dataUtil = new DataUtil();

            MethodInfo? intMethod = methodInfo?.MakeGenericMethod(typeof(int));
            if(intMethod != null)
            {
                Assert.Throws<System.Reflection.TargetInvocationException>(() => 
                    intMethod?.Invoke(dataUtil, new object[]{"2147483648"}));
                Assert.Throws<System.Reflection.TargetInvocationException>(() => 
                    intMethod?.Invoke(dataUtil, new object[]{"-2147483649"}));
                Assert.Throws<System.Reflection.TargetInvocationException>(() => 
                    intMethod?.Invoke(dataUtil, new object[]{"not a number"}));
                Assert.Throws<System.Reflection.TargetInvocationException>(() => 
                    intMethod?.Invoke(dataUtil, new object[]{"-"}));
                Assert.Throws<System.Reflection.TargetInvocationException>(() => 
                    intMethod?.Invoke(dataUtil, new object[]{""}));
                Assert.Throws<System.Reflection.TargetInvocationException>(() => 
                    intMethod?.Invoke(dataUtil, new object[]{" "}));
            }
        }
        
        [Fact]
        public void ConvertTypeTest_Double()
        {
            MethodInfo? methodInfo = 
                typeof(DataUtil).GetMethod("ConvertType", 
                BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.NotNull(methodInfo);
            DataUtil dataUtil = new DataUtil();

            MethodInfo? doubleMethod = methodInfo?.MakeGenericMethod(typeof(double));
            if(doubleMethod != null)
            {
                object? result = null;
                result = 
                    doubleMethod?.Invoke(dataUtil, new object[]{"0"});
                Assert.Equal((double)0, result);
                result = 
                    doubleMethod?.Invoke(dataUtil, new object[]{"2147483647"});
                Assert.Equal((double)2147483647, result);
                result = 
                    doubleMethod?.Invoke(dataUtil, new object[]{"-2147483648"});
                Assert.Equal((double)-2147483648, result);
                result = 
                    doubleMethod?.Invoke(dataUtil, new object[]{"42"});
                Assert.Equal((double)42, result);
                result = 
                    doubleMethod?.Invoke(dataUtil, new object[]{"3141592"});
                Assert.Equal((double)3141592, result);
                result = 
                    doubleMethod?.Invoke(dataUtil, new object[]{"-3141592"});
                Assert.Equal((double)-3141592, result);
            }
        }

        [Fact]
        public void ConvertTypeTest_Double_Error()
        {
            MethodInfo? methodInfo = 
                typeof(DataUtil).GetMethod("ConvertType", 
                BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.NotNull(methodInfo);
            DataUtil dataUtil = new DataUtil();

            MethodInfo? doubleMethod = methodInfo?.MakeGenericMethod(typeof(double));
            if(doubleMethod != null)
            {
                Assert.Throws<System.Reflection.TargetInvocationException>(() => 
                    doubleMethod?.Invoke(dataUtil, new object[]{"not a number"}));
                Assert.Throws<System.Reflection.TargetInvocationException>(() =>
                    doubleMethod?.Invoke(dataUtil, new object[]{"-"}));
                Assert.Throws<System.Reflection.TargetInvocationException>(() => 
                    doubleMethod?.Invoke(dataUtil, new object[]{" "}));
                Assert.Throws<System.Reflection.TargetInvocationException>(() => 
                    doubleMethod?.Invoke(dataUtil, new object[]{""}));
            }
        }
    }
}