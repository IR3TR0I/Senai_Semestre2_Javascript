import React from 'react-dom';
import { Route, BrowserRouter as Router, Switch, Redirect} from 'react-router-dom'
import { parseJwt, usuarioAutenticado } from './services/auth';


import './index.css';


import App from './Paginas/home/App';
import Login from './Paginas/Login/Login.Js';
import CadastrarConsulta from './Paginas/Consultas/CadastrarConsultaAdm';
import ListarConsultas from './Paginas/Consultas/ListarConsultasPaciente'
import NotFound from './Paginas/Notfound/NotFound';

import reportWebVitals from './reportWebVitals';


//constante para ver se o usúario pode entrar nas paginas que apenas o adm pode
const PermissaoAdm = ({ component : Component }) => (
  <Route
    render = {props =>
      usuarioAutenticado() && parseJwt().role === "3" ?
      //verifica se o usuário que logou é um adm
      <Component {...props} /> :
      //caso não, Volta pra página de Login
      <Redirect to ='login'/>
    }
  />
);

//PÁGINAS
// renderizando as paginas de acordo com as rotas
const routing = (
  <Router>
    <div>
      <Switch>
        <Route exact path="/" component = {App} /> 
        <Route path="/login" component = {Login} />
        <Route path="/Cadastrarconsulta" component= {CadastrarConsulta}/>
        <Route path="/ListarConsultas" component={ListarConsultas}/>
        <Route exact path="/notfound" component={NotFound}/>
        <Redirect to = "/notfound"/> {/*Volta para pagina NotFound*/}
      </Switch>
    </div>
  </Router>
)

ReactDOM.render(routing, document.getElementById('root'));

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
