def analise(lista):
    media = sum(lista) / len(lista)
    lista_ordenada = sorted(lista)
    tamanho = len(lista_ordenada)
    
    if tamanho % 2 == 0:
        mediana = (lista_ordenada[tamanho // 2 - 1] + lista_ordenada[tamanho // 2]) / 2
    else:
        mediana = lista_ordenada[tamanho // 2]
    
    minimo = min(lista)
    maximo = max(lista)
    
    return media, mediana, minimo, maximo
