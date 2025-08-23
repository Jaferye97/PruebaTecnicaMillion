import Swal from 'sweetalert2';

const BASE_URL = import.meta.env.VITE_API_URL_BASE;
const BASE_API = import.meta.env.VITE_API_URL_API;
const DEFAULT_ERROR_MESSAGE = 'Error al procesar la solicitud';

export const requestData = async (method, url, data = null) => {
  try {
    const headers = {
      'Content-Type': 'application/json',
    };

    const config = {
      method,
      headers,
      body: data ? JSON.stringify(data) : undefined,
    };

    const response = await fetch(BASE_URL + BASE_API + url, config);

    const json = await response.json();

    let errorMessage;

    switch (response.status) {
      case 404:
        errorMessage = 'Recurso no encontrado.';
        break;
      case 500:
        errorMessage = 'Ocurrió un error inesperado. Por favor comunícate con el área de soporte.';
        break;
      default:
        break;
    }

    if (errorMessage) {
      Swal.fire({
        icon: 'warning',
        title: errorMessage || DEFAULT_ERROR_MESSAGE,
        position: 'center',
        showConfirmButton: false,
        timer: 1500,
      });
    }

    return json;
  } catch (error) {
    Swal.fire({
      icon: 'error',
      title: 'Error',
      text: error.message || DEFAULT_ERROR_MESSAGE,
      position: 'center',
      showConfirmButton: false,
      timer: 1500,
    });

    console.error('Error al hacer la petición:', error.message);
  }
};
