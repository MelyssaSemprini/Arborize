const modal = document.getElementById('modal');
const btn = document.getElementById("open-modal");
const span = document.getElementsByClassName("close")[0];

// Quando o usuário clica no botão, abrir o modal e desativar o scroll
btn.onclick = function() {
  modal.style.display = "flex"; // Define 'flex' para centralizar o modal
}

// Quando o usuário clica no "x", fechar o modal e reativar o scroll
span.onclick = function() {
  modal.style.display = "none";
  document.body.style.overflow = "auto"; // Reativa o scroll
}

// Quando o usuário clica fora do modal, fechá-lo e reativar o scroll
window.onclick = function(event) {
  if (event.target == modal) {
    modal.style.display = "none";
    document.body.style.overflow = "auto"; // Reativa o scroll
  }
}

document.addEventListener("DOMContentLoaded", function() {
    modal.style.display = "none";
});
