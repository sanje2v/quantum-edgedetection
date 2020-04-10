using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;


namespace Quantum.quantum_edgedetection
{
    class Driver
    {
        static void Main(string[] args)
        {
            var filename = new string(@"..\..\..\demo.bmp");
            var org_img = new Bitmap(filename);
            var n_pixels = 2 ^ 5;

            using (var img = new Bitmap(org_img, new Size(n_pixels, n_pixels)))
            {
                org_img.Dispose();

                var data = new double[img.Height * img.Width];
                for (var i = 0; i < img.Width; ++i)
                    for (var j = 0; j < img.Height; ++j)
                        data[i * img.Height + j] = (img.GetPixel(i, j).R / 255.0d);

                var n_qubits = (int)Math.Log2(data.Length);
                using (var qsim = new QuantumSimulator())
                {
                    EdgeDetection.Run(qsim, n_qubits).Wait();
                }
            }
        }
    }
}