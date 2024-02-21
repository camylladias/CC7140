from random import randint

def lancar_dados():
    dado1 = randint(1, 6)
    dado2 = randint(1, 6)
    return dado1 + dado2

def main():
    resultados = {}
    total_lancamentos = 1000
    
    # Simular 1000 lançamentos de dois dados
    for _ in range(total_lancamentos):
        soma = lancar_dados()
        if soma in resultados:
            resultados[soma] += 1
        else:
            resultados[soma] = 1
    
    # Exibir os resultados como uma tabela
    print("Resultado\tFrequência\tPorcentagem")
    for resultado, frequencia in sorted(resultados.items()):
        porcentagem = (frequencia / total_lancamentos) * 100
        print(f"{resultado}\t\t{frequencia}\t\t{porcentagem:.2f}%")

if __name__ == "__main__":
    main()
