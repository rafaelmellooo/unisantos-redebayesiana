import logging
from json import dumps
from .methods import init_dataframe, script

import azure.functions as func


def main(req: func.HttpRequest) -> func.HttpResponse:
    logging.info('Python HTTP trigger function processed a request.')

    df_masc = init_dataframe('M')
    df_fem = init_dataframe('F')

    try:
        req_body = req.get_json()
    except ValueError:
        pass
    else:
        nomes = req_body.get('nomes')
        classificacoes = []
        for nome in nomes:
            classificacoes.append(script(nome, df_masc, df_fem))


    return func.HttpResponse(
        dumps(classificacoes),
        status_code=200
    )