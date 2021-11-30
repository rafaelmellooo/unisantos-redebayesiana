import pandas as pd
from math import log

def init_dataframe(genero: str) -> pd.DataFrame:
    """Retorna o dataframe para o gênero passado via parâmetro."""

    df_nomes = pd.read_csv('https://gist.githubusercontent.com/rafaelmellooo/d9c8149e3e395919f7d84bec0b4eec35/raw/0dcf7605cb3d4624cbb741278501d5329a2ac8a4/nomes.csv')
    df_nomes['Nome'] = df_nomes['Nome'].str.lower()
    df_genero = df_nomes[df_nomes['Gênero'] == genero.upper()]
    return df_genero


def frequencias(df: pd.DataFrame) -> pd.DataFrame:
    """Retorna a frequência de cada letra com base no dataframe."""

    freq_letras = {}
    for nome in df['Nome']:
        for letra in nome:
            if letra not in freq_letras.keys():
                freq_letras.update({letra: [letra, df['Nome'].str.count(letra).sum()]})

    df_freq = pd.DataFrame.from_dict(freq_letras, orient='index', columns=['Letra', 'Frequência'])
    df_freq.reset_index(drop=True, inplace=True)
    return df_freq


def probabilidade(nome: str, df: pd.DataFrame) -> int:
    """Retorna a probabilidade de cada letra do nome aparecer, baseado no dataframe."""

    prob = 0
    total_letras = df['Frequência'].sum()
    for letra in nome:
        prob += log(df['Frequência'][df['Letra'] == letra]/total_letras)

    return prob


def classificacao(prob_masc: int, prob_fem: int) -> int:
    """Retorna o gênero (0 para 'Feminino' ou 1 para 'Masculino')."""
    
    if prob_fem > prob_masc:
        return 0
    else:
        return 1


def script(nome: str, df_masc: pd.DataFrame, df_fem: pd.DataFrame) -> str:
    """Retorna o resultado da classificação como string ('Masculino' ou 'Feminino')."""

    df_freq_letras_masc = frequencias(df_masc)
    df_freq_letras_fem = frequencias(df_fem)

    nome = nome.lower()

    prob_masc = probabilidade(nome, df_freq_letras_masc)
    prob_fem = probabilidade(nome, df_freq_letras_fem)

    if classificacao(prob_masc, prob_fem):
        return 'Masculino'
    else:
        return 'Feminino'