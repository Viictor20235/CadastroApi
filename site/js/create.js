function CreatePessoa(){
    const primeiroNome = document.getElementById("firstName").value;
    const segundonome = document.getElementById("middleName").value;
    const ultimoNome = document.getElementById("lastName").value;
    const CPF = document.getElementById("cpf").value;

    const data ={

        primeiroNome: primeiroNome ,
        nomeMeio: segundonome,
        ultimoNome:ultimoNome,
        CPF: CPF,
    }

    


fetch('https://localhost:7236/api/Pessoa/create', {

    method: 'POST',
    headers:{
        'Content-Type': 'application/json'
    },
    body:JSON.stringify(data) 
}  ).then(response=>{
     if(!response.ok){
     
        alert("Erro ao criar pessoa");
    }
     alert("pessoa criada com sucesso!");
     window.location.href= '../index.html';
})
}
