import Button from '@mui/material/Button';
import DeleteIcon from '@mui/icons-material/Delete';
import './App.css';

function App() {
  return (
    <>
      <div className="flex h-screen items-center justify-center bg-gray-800 text-white">
        <h1 className="text-4xl font-bold">React + Vite + Tailwind funcionando ✅</h1>
      </div>
      <div className="p-10">
        <Button
          variant="contained"
          startIcon={<DeleteIcon />}
        >
          Eliminar
        </Button>
      </div>
    </>
  );
}

export default App;
