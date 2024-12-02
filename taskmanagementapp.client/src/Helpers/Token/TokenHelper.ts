export class TokenHelper implements ITokenHelper{
  async  getToken(): Promise<string | null> {
    const token = localStorage.getItem('token');
    return token;
    }
}