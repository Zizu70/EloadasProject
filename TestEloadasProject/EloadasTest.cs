using EloadasProject;
using NUnit.Framework;
using System;



namespace TestEloadasProject
{
    public class Tests
    {
        //Eloadas eloadas;

        [SetUp]
        public void Setup()
        {
                       
        }

        [Test] //1.
        public void Lefoglal_Ha_Van_Szabadhely()  //igaz
        {
            int sorok = 5;
            int helyek = 10;
            var eloadas = new Eloadas(sorok, helyek);

            // Act
            bool success = eloadas.Lefoglal();

            // Assert
            Assert.IsTrue(success);
        }
   

        [Test] //2.OK
        public void Lefoglal_Ha_Nincs_Szabadhely() //Hamis
        {
            int sorok = 2;
            int helyek = 2;
            var eloadas = new Eloadas(sorok, helyek);
            for (int i = 0; i < sorok; i++)
            {
                for (int j = 0; j < helyek; j++)
                {
                    eloadas.Lefoglal();
                }
            }

            // Act
            bool success = eloadas.Lefoglal();

            // Assert
            Assert.IsFalse(success);
        }
        

        [Test] //3.OK
        public void SzabadHelyek_Helyes_Ertekkel()  // helyes
        {
            // Arrange
            int sorok = 3;
            int helyek = 4;
            var eloadas = new Eloadas(sorok, helyek);
            eloadas.Lefoglal();
            eloadas.Lefoglal();
            for (int i = 0; i < sorok; i++)
            {
                for (int j = 0; j < helyek; j++)
                {
                    eloadas.Lefoglal();
                }
            }

            // Act
            int szabadHelyek = eloadas.SzabadHelyek();

            // Assert
            Assert.AreEqual(0, szabadHelyek); //0 volt azzal rossz!
        }

        [Test]  //4.
        public void Megtelt_Ha_Nincs_SzabadHely() //=> igaz
        {
            int sorok = 2;
            int helyek = 2;
            var eloadas = new Eloadas(sorok, helyek);
            for (int i = 0; i < sorok; i++)
            {
                for (int j = 0; j < helyek; j++)
                {
                    eloadas.Lefoglal();
                }
            }

            // Act
            bool megtelt = eloadas.Megtelt();

            // Assert
            Assert.IsTrue(megtelt);
        }

        [Test]  //5.OK
        public void Foglalt_Ervenytelen_Sor_Vagy_Oszlop()  //=> kivételt dob
        {
            int sorokSzama = 3;
            int helyekSzama = 3;
            var eloadas = new Eloadas(sorokSzama, helyekSzama);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => eloadas.Foglalt(0, 2));
            Assert.Throws<ArgumentException>(() => eloadas.Foglalt(4, 2));
            Assert.Throws<ArgumentException>(() => eloadas.Foglalt(2, 0));
            Assert.Throws<ArgumentException>(() => eloadas.Foglalt(2, 4));
        }

        [Test]  //6.OK
        public void Foglalt_Ervenyes_Sor_Vagy_Oszlop()  //=> helyes
        {

            // Arrange
            int sorok = 3;
            int helyek = 3;
            var eloadas = new Eloadas(sorok, helyek);
            eloadas.Lefoglal();

            // Act
            bool foglalt = eloadas.Foglalt(1, 1);

            // Assert
            Assert.IsTrue(foglalt);
        }
    }
}