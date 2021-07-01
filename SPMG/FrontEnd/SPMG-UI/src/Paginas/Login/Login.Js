import React, { Component } from 'react';
import { parseJwt, usuarioAutenticado } from '../../services/auth';

class Login extends Component {
    constructor(props) {
        super(props);
        this.state = {
          email : '',
          senha : '',
          erroMensagem : '',
          isLoading : false,
          isSuccessful : false,
        };
    }
    
    
    //função chamando a API para login
    fazerLogin = (event) => {
        //Ignorar o comportamento padrão de recarregar a página
        event.preventDefault();

        this.setState({ erro : '', isLoading:true });

        axios.post("", {
            email: this.state.email,
            senha : this.state.senha
        })

        //caso contrário
        .then((resposta) => {
            //Se a API retornar o Status code 200(Funcionando com sucesso!)
            if (resposta.status === 200) {
                localStorage.setItem("usuario-login", resposta.data.token)
                console.log("Seu token é este: " + resposta.data.token);

                this.setState({isLoading : false})
                this.setState({ isSuccessful: true });

                console.log(parseJwt());
                console.log(parseJwt().role);

                switch (parseJwt().role) {
                    case "1":
                        console.log(usuarioAutenticado());
                        this.props.history.push('/');
                        break;

                    case"2":
                        console.log(usuarioAutenticado());
                        this.props.history.push('/medico/consultas');
                        break;

                    case"3":
                        console.log(usuarioAutenticado());
                        this.props.history.push('/paciente/consultas');
                        break;

                    default:
                        console.log(usuarioAutenticado());
                        this.props.history.push('/');
                        break;
                }
            }
        })

        .catch(() => {
            this.setState({
                erroMensagem: "Seu E-mail ou senha inválidos! Tente de novo",
                isLoading: false,
                isSuccessful : false,
            })
        })
    }

    atualizaStateCampo = (campo) => {
        this.setState({ [campo.target.name]: campo.targe.values });
    };



    render() {   

        return (

            <div>

                <Header />

                <main>

                    <section className="content">

                        <div className="login-titulo">
                            <h1>LOGIN</h1>
                        </div>

                        <form onSubmit={this.EfetuarLogin}>

                            <input
                                type="text"
                                className="campo-email"
                                placeholder="Insira o seu email"
                                name="emailUser"
                                value={this.state.emailUser}
                                onChange={this.AtualizaStateCampo}
                            />

                            <input
                                type="password"
                                className="campo-senha"
                                placeholder="Insira a sua senha"
                                name="senhaUser"
                                value={this.state.senhaUser}
                                onChange={this.AtualizaStateCampo}
                            />

                            {
                                this.state.isLoading === true &&
                                <div>
                                    <button
                                        className="btn-entrar"
                                        type="submit"
                                        disabled
                                    >
                                        LOADING
                                    </button>
                                </div>
                            }

                            {
                                this.state.isLoading === false &&
                                <div>
                                    <button
                                        className="btn-entrar"
                                        type="submit"
                                        disabled={this.state.emailUser === '' || this.state.senhaUser === '' ? 'none' : ''}
                                    >
                                        ENTRAR
                                    </button>
                                </div>
                            }

                            <p className="msg-erro"> {this.state.erroMensagem} </p>

                        </form>

                    </section>

                </main>

                <Footer />

            </div>

        )

    }

}


export default Login;