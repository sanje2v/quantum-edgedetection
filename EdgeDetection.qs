namespace Quantum.quantum_edgedetection {
    open Microsoft.Quantum.Intrinsic;
    open Microsoft.Quantum.Canon;

    operation EdgeDetection(n_qubits : Int) : Unit {
        Message("Edge detection in quantum world!");

        using (registers = Qubit[n_qubits]) {
            

            ResetAll(registers);
		}
    }
}