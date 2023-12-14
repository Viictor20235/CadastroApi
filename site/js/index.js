document.addEventListener('DOMContentLoaded', function(){
     const pessoaLista = document.getElementById('pessoa-lista');
     function renderTable(data){
        console.log(data)
         pessoaLista.innerHTML = '';
         data.forEach(pessoa => {
             const row = document.createElement('tr');
              row.innerHTML = `
                 <td>${pessoa.pessoaId}</td>
                 <td>${pessoa.primeiroNome}</td>
                 <td>${pessoa.nomeMeio}</td>
                 <td>${pessoa.ultimoNome}</td>
                 <td>${pessoa.cpf}</td>
                 <td>
                     <button>Editar</button>
                     <button>Excluir</button>
                 </td>
            `;
             pessoaLista.appendChild(row);
        })
    }
     function feachPessoas(){
        fetch('https://localhost:7236/api/Pessoa/getall')
        .then(response => response.json())
        .then(data => renderTable(data))
        .catch(error => console.error('Erro ao buscar dados da Api'))
    }
     feachPessoas();
})
     
     function  AbrirTelaCreate(){
     window.location.href= 'pages/create.html';
}