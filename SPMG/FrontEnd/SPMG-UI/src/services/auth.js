//criando um serivço de autenticação de usuario utilizando o valor da role que foi pega do armazenamento local do token gerado pelo JWToken.

//gerando uma função de usuarioautenticado                                                  
export const usuarioAutenticado = () => localStorage.getItem('usuario-login') !== null;

// criando função que passa o token para Jwt
export const parseJwt = () => {
    //cria a var base64 puxa o token da chave/string ""usuario-login" e quebra ela em tres partes delimitada pelo methodo split.
    //o numero "1" pega todo o valor do payload do token
    let base64 =localStorage.getItem("usuario-login").split('.')[1];
    //retorna o token decodificado pelo metodo atob e armazenando o token na base64.
    return JSON.parse(window.atob(base64));
}