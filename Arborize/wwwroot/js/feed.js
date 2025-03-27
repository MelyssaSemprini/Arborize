const logo = document.getElementById('logo');
const sidebar = document.getElementById('sidebar');
const overlay = document.getElementById('overlay');

// Abrir/fechar a sidebar ao clicar no logo
logo.addEventListener('click', function() {
    sidebar.classList.toggle('open');  // Alterna a classe 'open'
    overlay.classList.toggle('show');  // Exibe/esconde o overlay
});

// Fechar a sidebar ao clicar no overlay
overlay.addEventListener('click', function() {
    sidebar.classList.remove('open');  // Remove a classe 'open'
    overlay.classList.remove('show');  // Esconde o overlay
});

  // Funções JavaScript para abrir e fechar o modal
  const modal = document.getElementById("addPostModal");
  const openModalBtn = document.getElementById("openModalBtn");
  const closeModalBtn = document.querySelector(".close");
  const submitPostBtn = document.getElementById("submitPostBtn");
  const uploadButton = document.getElementById("uploadButton");
  const postImage = document.getElementById("postImage");
  const postDate = document.getElementById("postDate");

  // Define a data atual no campo de data ao abrir o modal
  function setTodayDate() {
    const today = new Date();
    const year = today.getFullYear();
    const month = String(today.getMonth() + 1).padStart(2, '0');
    const day = String(today.getDate()).padStart(2, '0');
    postDate.value = `${year}-${month}-${day}`;
  }

  // Abre o modal e define a data atual
  openModalBtn.onclick = function() {
    modal.style.display = "flex";
    setTodayDate();
  }

  // Fecha o modal ao clicar no "x"
  closeModalBtn.onclick = function() {
    modal.style.display = "none";
  }

  // Fecha o modal ao clicar fora do conteúdo do modal
  window.onclick = function(event) {
    if (event.target == modal) {
      modal.style.display = "none";
    }
  }

  // Quando o botão de upload é clicado, aciona o campo de arquivo
  uploadButton.onclick = function() {
    postImage.click();
  }

  // Exibir o nome do arquivo selecionado no botão de upload
  postImage.onchange = function() {
    if (postImage.files.length > 0) {
      uploadButton.textContent = postImage.files[0].name;
    }
  }

  // Ação ao clicar em "Postar"
  submitPostBtn.onclick = function() {
    const date = postDate.value;
    const location = document.getElementById("postLocation").value;
    const image = postImage.files[0];
    const description = document.getElementById("postDescription").value;
    
    if (date && location && image && description) {
      console.log("Data do post:", date);
      console.log("Localização:", location);
      console.log("Imagem selecionada:", image);
      console.log("Descrição:", description);
      modal.style.display = "none"; // Fecha o modal
    } else {
      alert("Por favor, preencha todos os campos.");
    }
  }