public class No{

    //Atributos - Características
    public int valor; //Valor do Nó
    public No prox; //Ponteiro ou apontador para o próximo Nó

    //Construtor
    public No(int Valor){
        this.valor = Valor;
        this.prox = null;
    }

    //Métodos
    public void imprimir(){
        Console.WriteLine("Valor: " + this.valor);
    }
}