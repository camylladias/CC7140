from random import seed, randint

def criar_matriz():
    matriz = [[randint(0, 10) for _ in range(12)] for _ in range(12)]
    return matriz

def imprimir_matriz(matriz):
    for linha in matriz:
        for elemento in linha:
            print("%3d" % elemento, end=" ")
        print()

def calcular_operacao(matriz, operacao):
    total = 0
    elementos = 0
    for i in range(12):
        for j in range(12):
            if j < 11 - i:
                total += matriz[i][j]
                elementos += 1
    if operacao == 'M':
        resultado = total / elementos
        resultado = int(resultado)  # Converter para inteiro
    else:
        resultado = total
    return resultado

# Removendo a seed para permitir diferentes matrizes em cada execução
# seed(10)
operacao = input().strip().upper()

matriz = criar_matriz()

print("Matriz criada:")
imprimir_matriz(matriz)

resultado = calcular_operacao(matriz, operacao)

if operacao == 'M':
    print("Resultado da conta:", resultado)
else:
    print("Resultado da conta:", resultado)
