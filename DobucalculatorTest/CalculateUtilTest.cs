﻿using Xunit;
using DobuCalCulator;
using System.Reflection;
using System.Numerics;

namespace DobucalculatorTest
{
    public class CalculateUtilTest
    {
        [Fact]
        public void BinomialDistributionTest()
        {
            CalculateUtil calculateUtil = new CalculateUtil();
            ResultData binomialResult = calculateUtil.
                GetBinomialDistribution(new BinomialData(10, 50, 5));
            Assert.Equal("245952", binomialResult.result.ToString());
            Assert.Equal(4, binomialResult.decimalPoint);
            // 22.68%

            binomialResult = calculateUtil.
                GetBinomialDistribution(new BinomialData(100, 50, 5));
            Assert.Equal("59326565760", binomialResult.result.ToString());
            Assert.Equal(31, binomialResult.decimalPoint);
            // 0.000000000527012640 -> 0.0527012640(%)

            binomialResult = calculateUtil.
                GetBinomialDistribution(new BinomialData(1, 100, 1));
            Assert.Equal("100", binomialResult.result.ToString());
            Assert.Equal(0, binomialResult.decimalPoint);
            // 100%

            binomialResult = calculateUtil.
                GetBinomialDistribution(new BinomialData(1, 0, 1));
            Assert.Equal("0", binomialResult.result.ToString());
            Assert.Equal(0, binomialResult.decimalPoint);
            // 0%
        }

        [Fact]
        public void BinomialFaluareDistributionTest()
        {
            CalculateUtil calculateUtil = new CalculateUtil();
            ResultData binomialResult = calculateUtil.
                GetBinomialFailureDistribution(new BinomialData(10, 50, 5));
            Assert.Equal("376736", binomialResult.result.ToString());
            Assert.Equal(4, binomialResult.decimalPoint);
            // 15.84%

            binomialResult = calculateUtil.
                GetBinomialFailureDistribution(new BinomialData(10, 100, 10));
            Assert.Equal("0", binomialResult.result.ToString());
            Assert.Equal(0, binomialResult.decimalPoint);
            // 15.84%

            binomialResult = calculateUtil.
                GetBinomialFailureDistribution(new BinomialData(10, 0, 10));
            Assert.Equal("100", binomialResult.result.ToString());
            Assert.Equal(0, binomialResult.decimalPoint);
        }

        [Fact]
        public void BinomialDobuDistributionTest()
        {
            CalculateUtil calculateUtil = new CalculateUtil();

            ResultData binomialResult = calculateUtil.
                GetBinomialDistribution(new BinomialData(10, 50, 0));
            ResultData binomialDobuResult = calculateUtil.
                GetBinomialDobuDistribution(new BinomialData(10, 50, 5));
            
            Assert.Equal(binomialResult.result, binomialDobuResult.result);
            Assert.Equal(binomialResult.decimalPoint, binomialDobuResult.decimalPoint);
        }

        [Fact]
        public void FactorialTest()
        {
            MethodInfo? methodInfo = 
                typeof(CalculateUtil).GetMethod("GetPositiveFactorial", 
                BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.NotNull(methodInfo);
            CalculateUtil calculateUtil = new CalculateUtil();
            if(methodInfo != null)
            {
                object? result = methodInfo.Invoke(calculateUtil, new object[]{0});
                Assert.Equal("1", result?.ToString());
                result = methodInfo.Invoke(calculateUtil, new object[]{1});
                Assert.Equal("1", result?.ToString());
                result = methodInfo.Invoke(calculateUtil, new object[]{5});
                Assert.Equal("120", result?.ToString());
                result = methodInfo.Invoke(calculateUtil, new object[]{10});
                Assert.Equal("3628800", result?.ToString());
                result = methodInfo.Invoke(calculateUtil, new object[]{100});
                Assert.Equal("93326215443944152681699238856266700490715968264381621468592963895217599993229915608941463976156518286253697920827223758251185210916864000000000000000000000000", result?.ToString());
                result = methodInfo.Invoke(calculateUtil, new object[]{200});
                Assert.Equal("788657867364790503552363213932185062295135977687173263294742533244359449963403342920304284011984623904177212138919638830257642790242637105061926624952829931113462857270763317237396988943922445621451664240254033291864131227428294853277524242407573903240321257405579568660226031904170324062351700858796178922222789623703897374720000000000000000000000000000000000000000000000000", result?.ToString());
                result = methodInfo.Invoke(calculateUtil, new object[]{1000});
                Assert.Equal("402387260077093773543702433923003985719374864210714632543799910429938512398629020592044208486969404800479988610197196058631666872994808558901323829669944590997424504087073759918823627727188732519779505950995276120874975462497043601418278094646496291056393887437886487337119181045825783647849977012476632889835955735432513185323958463075557409114262417474349347553428646576611667797396668820291207379143853719588249808126867838374559731746136085379534524221586593201928090878297308431392844403281231558611036976801357304216168747609675871348312025478589320767169132448426236131412508780208000261683151027341827977704784635868170164365024153691398281264810213092761244896359928705114964975419909342221566832572080821333186116811553615836546984046708975602900950537616475847728421889679646244945160765353408198901385442487984959953319101723355556602139450399736280750137837615307127761926849034352625200015888535147331611702103968175921510907788019393178114194545257223865541461062892187960223838971476088506276862967146674697562911234082439208160153780889893964518263243671616762179168909779911903754031274622289988005195444414282012187361745992642956581746628302955570299024324153181617210465832036786906117260158783520751516284225540265170483304226143974286933061690897968482590125458327168226458066526769958652682272807075781391858178889652208164348344825993266043367660176999612831860788386150279465955131156552036093988180612138558600301435694527224206344631797460594682573103790084024432438465657245014402821885252470935190620929023136493273497565513958720559654228749774011413346962715422845862377387538230483865688976461927383814900140767310446640259899490222221765904339901886018566526485061799702356193897017860040811889729918311021171229845901641921068884387121855646124960798722908519296819372388642614839657382291123125024186649353143970137428531926649875337218940694281434118520158014123344828015051399694290153483077644569099073152433278288269864602789864321139083506217095002597389863554277196742822248757586765752344220207573630569498825087968928162753848863396909959826280956121450994871701244516461260379029309120889086942028510640182154399457156805941872748998094254742173582401063677404595741785160829230135358081840096996372524230560855903700624271243416909004153690105933983835777939410970027753472000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000", result?.ToString());           
            }
        }
    }
}