import { BrowserRouter, Route, Routes } from 'react-router-dom'
import './App.css';
import { Login } from './paginas/Login/Login';
import { Cadastro } from './paginas/Cadastro/Cadastro';
import { Biblioteca } from './paginas/Biblioteca/Biblioteca';
import { PlanosDeLeitura } from './paginas/PlanosDeLeitura/PlanosDeLeitura';
import { Home } from './paginas/Home/Home';

function App() {
  return (
    <BrowserRouter>
        <Routes>
            <Route path='/' element={<Login/>}/>
            <Route path='/home' element={<Home/>}/>
            <Route path='/cadastro' element={<Cadastro/>}/>
            <Route path='/biblioteca' element={<Biblioteca/>}/>
            <Route path='/planosdeleitura' element={<PlanosDeLeitura/>}/>
        </Routes>
    </BrowserRouter>
  );
}

export default App;
