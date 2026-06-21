using System;
using System.Collections.Generic;

public class KeywordResponder
{
    private Dictionary<string, List<string>> _responses;
    private Random _random = new Random();

    public KeywordResponder()
    {
        _responses = new Dictionary<string, List<string>>
        {
            {
                "password", new List<string>
                {
                    "Use at least 12 characters with uppercase, lowercase, numbers, and symbols.",
                    "Never reuse the same password across multiple sites — one breach exposes everything.",
                    "Consider using a password manager like Bitwarden or 1Password to stay secure.",
                    "Avoid using personal info like birthdays or names in your passwords."
                }
            },
            {
                "phishing", new List<string>
                {
                    "Phishing emails mimic trusted brands — always check the sender's actual email address.",
                    "Never click links in unexpected emails. Go directly to the website instead.",
                    "Look for urgent language like 'Act now!' — that's a classic phishing red flag.",
                    "Enable spam filters and report phishing emails to your email provider."
                }
            },
            {
                "privacy", new List<string>
                {
                    "Review your social media privacy settings regularly — platforms change defaults often.",
                    "Use a VPN on public networks to keep your browsing private.",
                    "Be cautious about what apps you grant microphone or camera access to.",
                    "Read privacy policies before signing up — look for data-sharing clauses."
                }
            },
            {
                "malware", new List<string>
                {
                    "Malware can be hidden in downloads, email attachments, or fake software updates.",
                    "Install reputable antivirus software and keep it updated at all times.",
                    "Avoid downloading software from unofficial or unfamiliar websites.",
                    "Ransomware is a type of malware that locks your files — always back up your data."
                }
            },
            {
                "scam", new List<string>
                {
                    "If someone asks for payment via gift cards or crypto, it's almost always a scam.",
                    "Verify any unexpected prize or lottery win directly — you can't win something you didn't enter.",
                    "Scammers often pretend to be banks or government agencies to steal your info.",
                    "When in doubt, hang up and call the official number listed on the company's website."
                }
            },
            {
                "wifi", new List<string>
                {
                    "Avoid doing online banking or shopping on public WiFi — use mobile data instead.",
                    "Use a VPN when connecting to public hotspots to encrypt your traffic.",
                    "Make sure your home router uses WPA3 encryption for better security.",
                    "Disable auto-connect on your device so it doesn't join rogue networks automatically."
                }
            },
            {
                "firewall", new List<string>
                {
                    "A firewall monitors incoming and outgoing traffic to block unauthorised access.",
                    "Always keep your OS firewall turned on — it's your first line of defence.",
                    "Businesses should use hardware firewalls in addition to software ones.",
                    "Configure your firewall rules carefully — overly open rules defeat the purpose."
                }
            },
            {
                "encryption", new List<string>
                {
                    "Encryption scrambles your data so only authorised parties can read it.",
                    "Always check for HTTPS in the browser bar — that means the connection is encrypted.",
                    "End-to-end encryption in apps like Signal means even the app provider can't read your messages.",
                    "Encrypt sensitive files before storing them in the cloud or on USB drives."
                }
            }
        };
    }

    // Returns a random response for a matched keyword, or null if no match
    public string GetResponse(string input)
    {
        input = input.ToLower();

        foreach (var keyword in _responses.Keys)
        {
            if (input.Contains(keyword))
            {
                var list = _responses[keyword];
                return list[_random.Next(list.Count)];
            }
        }

        return null; // No keyword matched
    }

    // Returns all known keywords (used for 'what can you do' responses)
    public List<string> GetAllKeywords()
    {
        return new List<string>(_responses.Keys);
    }
}