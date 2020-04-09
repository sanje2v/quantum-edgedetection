using System;
using System.Drawing;
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;


namespace Quantum.quantum_edgedetection
{
    class Driver
    {
        static void Main(string[] args)
        {
            string filename = new string(@"..\..\..\demo.bmp");
            Bitmap org_img = new Bitmap(filename);
            int n_pixels = 2 ^ 5;

            using (Bitmap img = new Bitmap(org_img, new Size(n_pixels, n_pixels)))
            {
                org_img.Dispose();

                using (var qsim = new QuantumSimulator())
                {
                    EdgeDetection.Run(qsim).Wait();
                }
            }
        }
    }
}