# RSA
## RSA encryption algorithm is a type of public-key encryption algorithm
### RSA algorithm uses the following procedure to generate public and private keys:

1. Select two large prime numbers, p and q.
2. Multiply these numbers to find n = p x q, where n is called the modulus for encryption and decryption.
3. Choose a number e less than n, such that n is relatively prime to (p - 1) x (q -1). It means that e and (p - 1) x (q - 1) have no common factor except 1. Choose "e"     such that 1<e < φ (n), e is prime to φ (n),
  gcd (e,d(n)) =1
4. If n = p x q, then the public key is <e, n>. A plaintext message m is encrypted using public key <e, n>. To find ciphertext from the plain text following formula is     used to get ciphertext C.
  C = me mod n
  Here, m must be less than n. A larger message (>n) is treated as a concatenation of messages, each of which is encrypted separately.
5. To determine the private key, we use the following formula to calculate the d such that:
	  De mod {(p - 1) x (q - 1)} = 1
	  Or
	  De mod φ (n) = 1
6. The private key is <d, n>. A ciphertext message c is decrypted using private key <d, n>. To calculate plain text m from the ciphertext c following formula is used to   get plain text m.
  m = cd mod n
