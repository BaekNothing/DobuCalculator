using Xunit;
using DobuCalCulator;
using System.Reflection;
using System.Numerics;

namespace DobucalculatorTest
{
    public class UserInterfaceUtilTest
    {
        [Fact]
        public void CheckNullableStringIsEmptyTest()
        {
            MethodInfo? methodInfo = 
                typeof(UserInterfaceUtil).GetMethod("CheckNullableStringIsEmpty", 
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            Assert.NotNull(methodInfo);
            UserInterfaceUtil UiUtil = new UserInterfaceUtil();

            object? result = null;
            result = 
                methodInfo?.Invoke(UiUtil, new object[]{string.Empty});
            Assert.True((bool)(result ?? false));
            result = 
                methodInfo?.Invoke(UiUtil, new object[]{""});
            Assert.True((bool)(result ?? false));

            result = 
                methodInfo?.Invoke(UiUtil, new object[]{" "});
            Assert.False((bool)(result ?? true));

            result = 
                methodInfo?.Invoke(UiUtil, new object[]{"not empty"});
            Assert.False((bool)(result ?? true));
        }

        [Fact]
        public void SetResultStringTest()
        {
            UserInterfaceUtil userInterfaceUtil = new UserInterfaceUtil();

            BigInteger input = 0;
            Assert.Equal(
                $"0%",
                userInterfaceUtil.SetResultString(new ResultData(input, 0, 1)));
            input = 1;
            Assert.Equal(
                $"100%",
                userInterfaceUtil.SetResultString(new ResultData(input, 0, 1)));

            input = 629391580;
            Assert.Equal(
                //its 0.629391580 -> 0.629391580(%)
                $"0.629391580%",
                userInterfaceUtil.SetResultString(new ResultData(input, 11, 1)));
            Assert.Equal(
                $"6.29391580%",
                userInterfaceUtil.SetResultString(new ResultData(input, 10, 1)));
            Assert.Equal(
                $"62.9391580%",
                userInterfaceUtil.SetResultString(new ResultData(input, 9, 1)));
        }
    }
}