// Lista.cs
using System; // Adicionado para Console.WriteLine

public class Lista //SE - Simplesmente Encadeada
{
    //Atributos
    public No inicio; //cabeça
    public No fim; //cauda

    //Construtor
    public Lista()
    {
        this.inicio = null;
        this.fim = null;
    }

    //Métodos
    public Boolean estaVazia()
    {
        if (inicio == null && fim == null)
        {
            return (true);
        }
        return (false);
    }

    public void inserirInicio(int valor)
    {
        //CRIAR NOVO NO
        No novoNo = new(valor);

        if (this.estaVazia()) //LISTA VAZIA!
        {
            this.inicio = novoNo;
            this.fim = novoNo;
        }
        else //LISTA NÃO ESTÁ VAZIA!
        {
            novoNo.prox = this.inicio; //Novo no aponta para o inicio da lista
            this.inicio = novoNo; //O inicio da lista passa a ser o novo no
        }
        Console.WriteLine($"Elemento {valor} inserido no início.");
    }

    // IMPLEMENTAÇÃO SOLICITADA: inserirFIM()
    public void inserirFIM(int valor)
    {
        No novoNo = new(valor);

        if (this.estaVazia())
        {
            this.inicio = novoNo;
            this.fim = novoNo;
        }
        else
        {
            this.fim.prox = novoNo; // O último nó atual aponta para o novo nó
            this.fim = novoNo;     // O novo nó se torna o fim da lista
        }
        Console.WriteLine($"Elemento {valor} inserido no fim.");
    }

    // IMPLEMENTAÇÃO SOLICITADA: removerInicio()
    public Boolean removerInicio()
    {
        if (this.estaVazia())
        {
            Console.WriteLine("A lista está vazia. Nada para remover do início.");
            return false;
        }

        int valorRemovido = this.inicio.valor;
        this.inicio = this.inicio.prox; // O início agora é o próximo nó

        if (this.inicio == null) // Se a lista ficou vazia após a remoção
        {
            this.fim = null;
        }
        Console.WriteLine($"Elemento {valorRemovido} removido do início da lista.");
        return true;
    }

    // IMPLEMENTAÇÃO SOLICITADA: removerFim()
    public Boolean removerFim()
    {
        if (this.estaVazia())
        {
            Console.WriteLine("A lista está vazia. Nada para remover do fim.");
            return false;
        }

        if (this.inicio == this.fim) // Apenas um elemento na lista
        {
            int valorRemovido = this.inicio.valor;
            this.inicio = null;
            this.fim = null;
            Console.WriteLine($"Elemento {valorRemovido} removido do fim da lista (era o único).");
            return true;
        }

        No noAtual = this.inicio;
        No noAnterior = null;

        // Percorre até o penúltimo nó
        while (noAtual.prox != null)
        {
            noAnterior = noAtual;
            noAtual = noAtual.prox;
        }

        // 'noAtual' é o último nó, 'noAnterior' é o penúltimo
        int valorRemovidoFim = noAtual.valor;
        noAnterior.prox = null; // O penúltimo nó agora aponta para null
        this.fim = noAnterior; // O penúltimo nó se torna o novo fim
        Console.WriteLine($"Elemento {valorRemovidoFim} removido do fim da lista.");
        return true;
    }


    public Boolean remover(int valor)
    {
        No noAnterior, noAtual;
        noAnterior = noAtual = null;

        Boolean verif = this.consulta(valor, ref noAtual, ref noAnterior);

        if (verif == true)
        { //Encontrou então remove!
            if (noAtual == this.inicio)
            { //Remover inicio
                this.inicio = noAtual.prox;
                // Se o início se tornou nulo, o fim também deve ser nulo
                if (this.inicio == null)
                {
                    this.fim = null;
                }
            }
            else if (noAtual == this.fim)
            { //Remover fim
                this.fim = noAnterior;
                if (noAnterior != null) // Garante que noAnterior não é nulo caso a lista tivesse apenas 1 item
                {
                    noAnterior.prox = null;
                }
            }
            else
            { //Remover no meio (entre dois nos)
                noAnterior.prox = noAtual.prox;
            }
            // Não é necessário setar noAtual para null em C#, o Garbage Collector fará isso.
            // noAtual = null;
            Console.WriteLine($"Elemento {valor} removido da lista.");
            return (true); //Retorna TRUE se removeu
        }
        Console.WriteLine($"Elemento {valor} não encontrado para remoção.");
        return (false); //Retorna FALSE se não removeu
    }

    public Boolean consulta(int valor, ref No noAtual, ref No noAnterior)
    { //BUSCA ELEMENTO NA LISTA
        noAtual = this.inicio; //Copia da lista
        noAnterior = null;
        while (noAtual != null)
        { //Percorrer lista
            if (noAtual.valor == valor)
            {
                return (true);
            }
            noAnterior = noAtual; //Copia do atual
            noAtual = noAtual.prox;
        }
        return (false);
    }

    public void imprimir()
    { //percorrer a lista...
        No noAux = this.inicio; //Copia do inicio da listsa

        Console.WriteLine("\n--- Elementos na Lista ---");
        if (this.estaVazia())
        {
            Console.WriteLine("A lista está vazia.");
            return;
        }

        while (noAux != null)
        {
            Console.Write(noAux.valor + " -> ");
            noAux = noAux.prox;
        }
        Console.WriteLine("NULL\n"); // Para indicar o fim da lista
    }
}