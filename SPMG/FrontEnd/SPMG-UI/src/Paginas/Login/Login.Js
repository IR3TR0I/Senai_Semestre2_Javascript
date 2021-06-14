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



    render() 
}

export default Login;