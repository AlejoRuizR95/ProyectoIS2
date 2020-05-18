using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicaNegocio;
using System.Collections.Generic;

namespace LogicaNegocioTest
    {

    [TestClass]
    public class ClsSalaTest
    {
        //ClsSala Sala = new ClsSala();
        [TestMethod]
        
        public void CalcularPrecioDomingoVIPDespuesdelas3()
        {
            double PrecioEsperado = 18000;
            //ClsSala.Calcular_Pago
            double PrecioLogNegocio = ClsSala.Calcular_Pago("9", "17/05/2020", "16:00:00");

            Assert.AreEqual(PrecioEsperado, PrecioLogNegocio);


        }
        [TestMethod]
        public void CalcularPrecioMiercolesVIP()
        {
            double PrecioEsperado = 9000;
            //ClsSala.Calcular_Pago
            double PrecioLogNegocio = ClsSala.Calcular_Pago("10", "13/05/2020", "11:00:00");

            Assert.AreEqual(PrecioEsperado, PrecioLogNegocio);


        }

        [TestMethod]
        public void CalcularPrecioMartesSinVIP()
        {
            double PrecioEsperado = 7500;
            //ClsSala.Calcular_Pago
            double PrecioLogNegocio = ClsSala.Calcular_Pago("6", "12/05/2020", "15:00:00");

            Assert.AreEqual(PrecioEsperado, PrecioLogNegocio);


        }

        [TestMethod]
        public void CalcularPrecioLunesSinVIP()
        {
            double PrecioEsperado = 9750;
            //ClsSala.Calcular_Pago
            double PrecioLogNegocio = ClsSala.Calcular_Pago("6", "11/05/2020", "13:00:00");

            Assert.AreEqual(PrecioEsperado, PrecioLogNegocio);


        }



    }
}
