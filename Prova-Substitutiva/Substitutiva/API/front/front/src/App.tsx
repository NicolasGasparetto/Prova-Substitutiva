import React from 'react';
import ListarAgendas from './components/IMC';
import { BrowserRouter, Link, Route, Routes } from 'react-router-dom';

function App() {
  return (
    <div className="App">
      <header className="App-header">
          <h1>IMC</h1>
            <div>
      <div>
        <BrowserRouter>
          <nav>
            <ul>
              <li>
                <Link to={"/"}>Home</Link>
              </li>
              <li>
                <Link to={"pages/imc/listar{id}"}>
                  Listar Imc{" "}
                </Link>
              </li>
              <li>
                <Link to={"pages/imc/cadastrar"}>
                  Cadastrar Imc{" "}
                </Link>
              </li>
            </ul>
          </nav>
          <Routes>
            <Route path="/" element={<ListarImcs />} />
            <Route
              path="/pages/agendas/listar"
              element={<ListarImc />}
            />
          </Routes>
          <footer>
          </footer>
        </BrowserRouter>
      </div>
    </div>
      </header>
    </div>
  );
}

export default App;
