import { BrowserRouter, Route, Routes } from 'react-router-dom'
import './App.css';
import { Login } from './paginas/Login/Login';
import { Cadastro } from './paginas/Cadastro/Cadastro';
import { Biblioteca } from './paginas/Biblioteca/Biblioteca';

function App() {
  return (
    <BrowserRouter>
        <Routes>
            <Route path='/' element={<Login/>}/>
            <Route path='/cadastro' element={<Cadastro/>}/>
            <Route path='/biblioteca' element={<Biblioteca/>}/>
        </Routes>
    </BrowserRouter>
  );
}

export default App;
