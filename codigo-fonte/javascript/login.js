// Função para redefinir senha add por Melyssa 

document.addEventListener('DOMContentLoaded', function() {
    document.querySelector('#exampleModal .btn-secondary').addEventListener('click', function () {
        const email = document.getElementById('recipient-name').value;
        console.log("E-mail capturado:", email); // Adicione esta linha

        if (email) {
            emailjs.send('service_hzvpxya', 'template_2ivxgxo', {
                to_email: email,
                message: 'Clique no link para redefinir sua senha: <a href="link-de-redefinicao">Redefinir Senha</a>'
            })
            .then(function(response) {
                alert('Email de redefinição de senha enviado com sucesso.');
                $('#exampleModal').modal('hide'); // Fecha o modal
            }, function(error) {
                alert('Erro ao enviar email de redefinição de senha. Tente novamente mais tarde.');
            });
        } else {
            alert('Por favor, preencha o campo de email.');
        }
    });
});

if (email.trim()) { // Adiciona .trim() para remover espaços
    // Código para enviar e-mail
} else {
    alert('Por favor, preencha o campo de email.');
}