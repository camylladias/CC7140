def criptCesar(frase, deslocamento):
    alfabeto = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ'
    resultado = ''
    
    for caractere in frase:
        if caractere.isalpha():  # Verifica se é uma letra
            indice = (alfabeto.index(caractere.upper()) + deslocamento) % 26
            novo_caractere = alfabeto[indice]
            resultado += novo_caractere if caractere.isupper() else novo_caractere.lower()
        else:
            resultado += caractere
    
    return resultado
