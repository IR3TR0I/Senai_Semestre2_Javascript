import {React, Component } from 'react'

class CadastroAdm extends Component {     
    constructor(props) {

        super(props)

        this.state = {
            idmedico: 0,
            idpaciente: 0,
            idsituacao: 1,  
            data: new Date(),
            descricaoConsulta: '',
            listaMedicos: [],
            listaPacientes: [],
            isLoading: false,
            confirmacao:''
            
        }
    }
    
    //Medicos
    BuscarMedicos = () => {

        console.log('fazendo chamada de api para medicos')

        fetch('http://localhost:5000/api/medicos'), {

            headers: {
                'Authorization': 'Bearer ' +localStorage.getItem('usuario-login')
            }
        }

        .then(resposta => resposta.json())

        .then(dados => this.setState({ListaMedicos: dados}))

        .catch(erro => console.log(erro))
    }

    //Pacientes

    BuscarPacientes= () => {

        console.log('chamando a API para os pacientes')

        fetch('http://localhost:5000/api/pacientes', {

            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })

        .then(resposta => resposta.json())

        .then(dados => this.setState({ListaPacientes: dados}))

        .catch(erro => console.log(erro))

    }

    CadastrarConsulta= (event) => {
        event.preventDefault()

        this.setState({ isLoading: true })

        fetch('http://localhost:5000/api/consultas', {
            method: 'POST',
            body: JSON.stringify({  
                idMedico: this.state.idmedico,
                idPaciente: this.state.idpaciente,
                idSituacao: this.state.idsituacao,
                dataConsulta: this.state.data,
                descricao: this.state.descricaoConsulta
            }),
            headers: {
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })

        .then(resposta => {
            if (resposta.status === 201) {
                console.log('Sua consulta foi cadastrada com sucesso')
    
                this.setState({
                    mensagemConfirmação: 'Consulta agendada com sucesso',
                    isLoading: false
                })
            }
        })
    
        .catch(erro => {
            console.log(erro)
            this.setState({isLoading:false})
        })
    
        .then(this.LimparCampos)
    }

    atualizaStateCampo= async (campo) => {
        await this.setState({[campo.target.name]: campo.target.value })
    }

    LimparCampos = () => {
        this.setState({
            idmedico: 0,
            idpaciente: 0,
            data: new Date(),
            descricaoConsulta: ''
        })
    }

    componentDidMount() {
        this.BuscarMedicos()
        this.BuscarPacientes()
    }

    render() {

        return (

            <div>

                <main>

                    <section className="content-cadastro">


                        <div className="user-box">
                            <p>ADMNISTRADOR</p>
                        </div>

                        <div className="cadastrar-consulta">
                            <h1>CADASTRAR CONSULTA</h1>
                        </div>


                        <form onSubmit={this.CadastrarConsulta}>


                            <section className="box-cadastro">


                                <div className="med-cadastro">

                                    <h2 className="titulos-cadastro">MÉDICO:</h2>

                                    <select
                                        name="idmedico"
                                        value={this.state.idmedico}
                                        onChange={this.AtualizaStateCampo}
                                    >

                                        <option value="0">
                                            Selecione o Médico
                                        </option>

                                        {
                                            this.state.listaMedicos.map(med => {
                                                return (
                                                    <option key={med.idMedico} value={med.idMedico}>
                                                        {med.nomeMedico}
                                                    </option>
                                                )
                                            })
                                        }

                                    </select>

                                </div>



                                <div className="pac-select">

                                    <h2 className="titulos-cadastro">NOME DO PACIENTE:</h2>

                                    <select
                                        name="idpaciente"
                                        value={this.state.idpaciente}
                                        onChange={this.AtualizaStateCampo}
                                    >

                                        <option value="0">
                                            Selecione o Paciente
                                        </option>

                                        {
                                            this.state.listaPacientes.map(pac => {
                                                return (
                                                    <option key={pac.idPaciente} value={pac.idPaciente}>
                                                        {pac.nomePaciente}
                                                    </option>
                                                )
                                            })
                                        }

                                    </select>

                                   
                                    <p className="pac-cadastro">Cadastrar Paciente</p>

                                </div>


                                <div className="data-cadastro">
                                    <h2 className="titulos-cadastro">DATA DE AGENDAMENTO:</h2>
                                    <input
                                        className="inputs-cadastro"
                                        type="date"
                                        name="data"
                                        value={this.state.data}
                                        onChange={this.AtualizaStateCampo}
                                        placeholder="Insira o nome do médico" />
                                </div>


                                <div className="descricao-cadastro">
                                    <h2 className="titulos-cadastro">DESCRIÇÃO:</h2>
                                    <input
                                        id="descricao-box"
                                        className="inputs-cadastro"
                                        type="text"
                                        name="descricaoConsulta"
                                        value={this.state.descricaoConsulta}
                                        onChange={this.AtualizaStateCampo}
                                        placeholder="Insira a descrição da consulta" />
                                </div>


                                {
                                    this.state.isLoading === true &&

                                    <button
                                        type="submit"
                                        id="btn-cadastrar"
                                        disabled
                                    >
                                        Agendando...
                                    </button>
                                }


                                {
                                    this.state.isLoading === false &&

                                    <button
                                        type="submit"
                                        id="btn-cadastrar"
                                    >
                                        Agendar
                                    </button>
                                }

                                <p className="msg-confirmacao"> {this.state.mensagemConfirmação} </p>


                            </section>

                        </form>


                    </section>


                </main>

            </div>

        )

    }
}
export default CadastroAdm