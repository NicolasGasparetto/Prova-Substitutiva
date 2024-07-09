import React, { useEffect, useState } from "react";
import { IMC } from "../models/Imc";

function ListarImc() {

    const [imcs, setImcs] = useState<IMCS[]>([]);

    useEffect(() => {
      V();
    }, []);
  
    function C() {
      //FETCH ou AXIOS
      fetch("http://localhost:pages/imc/listar{id}")
        .then((resposta) => resposta.json())
        .then((imcs: IMC[]) => {
          console.table(imcs);
          setAgendas(imcs);
        });
    }

    return(
            <div>
              <h1>Listar IMC</h1>
              <table>
                <tbody>
                  {agendas.map((imc) => (
                    <tr key={imc.Id}>
                      <td>{imc.nome}</td>
                      <td>{imc.datanasc}</td>
                      <td>{imc.altura}</td>
                      <td>{imc.peso}</td>
                      <td>{imc.}</td>
                      <td>{imc.classificação}</td>
                      <td>{imc.criacao}</td>
                      <td>
                        <button>
                          Alterar
                        </button>
                      </td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </div>
          );
        }

export default <ListarImc>;