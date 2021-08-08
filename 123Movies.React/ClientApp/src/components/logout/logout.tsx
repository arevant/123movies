import React from 'react';

const Logout: React.FC = (props: any) => {

  const [redirect, toggleRedirect] = React.useState(false);

  React.useEffect(() => {
    localStorage.removeItem('authtoken');
    toggleRedirect(true);
    setTimeout(() => {
      props.history.push('/login');
    }, 5000);

    return () => {
      toggleRedirect(false);
      clearTimeout();
    }
  })

  return (
    <div>
      <div>You have now been logged out. You will be redirected to login page in 5 seconds.</div>

      {redirect && <div>Redirecting...</div>}
    </div>
  );
}

export default Logout;
